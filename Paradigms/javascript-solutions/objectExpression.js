function cnst(c) { return c;}
var vars = {"x": 0, "y": 0, "z": 0};
function variable(vari) {return vars[vari];}
function add(){
    let res = 0; for (let i= 0; i < arguments.length;i++){res+=arguments[i];} return res;
    
}
function subtract(a, ...args) {return a-add(args);}
function multiply() {let res = 1; for (let i= 0; i < arguments.length;i++){res*=arguments[i];} return res;}
function divide(a, ...args) {return a/multiply(args);}
function negate(a) {return -a;}
function sinh(a) {return Math.sinh(a);}
function cosh(a) {return Math.cosh(a);}
	
function expr(x,y,z){
    vars["x"] = x;
    vars["y"] = y;
    vars["z"] = z;
    return add(multiply(variable("x"), variable("x")), negate(multiply(cnst(2), variable("x"))), cnst(1) );
}

var oper = {"+": add, "-": subtract, "*": multiply, "/": divide, "sinh": sinh, "cosh": cosh};

class Expr {
    constructor (a, b, operator){
        this.a = a;
        this.b = b;
        this.operator = operator;
        this.operate = oper[operator](a.operate,b.operate);
        return this.operate;
    }
    
    toString(){
        return this.a.toString()+" "+this.b.toString()+" "+this.operator;
    }
}

class Add extends Expr{
    constructor(a,b){
        super(a, b, "+");
    }
    diff(){
        return new Add(this.a.diff(), this.b.diff());
    }
}
class Subtract extends Expr{
    constructor (a,b){
        super(a, b, "-");
    }
    diff(){
        return new Subtract(this.a.diff(), this.b.diff());
    }
}
class Multiply extends Expr{
    constructor(a,b){
        super(a, b, "*");
    }
    diff(){
        return new Add(new Multiply(this.a.diff(), this.b), new Multiply(this.b.diff(), this.a));
    }
}
class Divide extends Expr{
    constructor(a,b){
        super(a, b, "/");
    }
     diff(){
        return new Divide(new Subtract(new Multiply(this.a.diff(), this.b), new Multiply(this.a, this.b.diff())), new Multiply(this.b, this.b));
    }
}

class Negate extends Expr{
    constructor(a){
        super(0, a, "-");
    }
    diff(){
        return new Negate(this.b.diff())
    }
}

class Const{
    constructor(a){
        this.operate = a;
        return a;
    }
    toString(){
        return this.operate;
    }
    diff(){
        return new Const(0);
    }
}

class Variable{
    constructor(a){
        this.operate = vars[a];
        return this.operate;
    }
    toString(){
        return this.operate;
    }
    diff(){
        return new Const(1);
    }
}

class Sinh extends Expr{
    constructor(a){
		super(0, a, "sinh");
	}
	diff(){
		return new Cosh(this.a);
	}
}
class Cosh extends Expr{
    constructor(a){
		super(0, a, "cosh");
	}
	diff(){
		return new Sinh(this.a);
	}
}


function parsePrefixOperator(str){
    let cursor = 0;
    function doNext(){
        let cur = str.charAt(cursor);
        cursor++; 
        if (cur == ' '){return doNext();}
        if (cur == '(') {
            let buf = new operClass[doNext()](doNext(), doNext());
            if (str.charAt(cursor)==')'){
            cursor++;
            return buf;
            
            }
            return -1;
        }
        if (cur in oper)
        return cur;
        if (cur in vars)
        return new Variable(cur);
        return new Const(cur);
        
    }
    cursor = doNext();
    if (cursor!=-1)
    return cursor;
    return "Failed";
    
}

function parse(str){
    
    let arr = str.split(" ")
    let st = [];
    for(let i = 0; i < arr.length; i++){
        let cur = new Variable(arr[i]);
        if (cur.operate){
            st.push(cur);
            continue;
        }
        cur = arr[i];
        if (cur=="+"){
            st.push(new Add(st.pop(), st.pop()));
            continue;
        }
        
        if (cur=="-"){
            st.push(new Subtract(st.pop(), st.pop()));
            continue;
        }
        
        if (cur=="*"){
            st.push(new Multiply(st.pop(), st.pop()));
            continue;
        }
        
        if (cur=="/"){
            st.push(new Divide(st.pop(), st.pop()));
            continue;
        }
		if (cur == "sinh"){
			st.push(new Sinh(st.pop));
			continue;
		}
		if (cur == "cosh"){
			st.push(new Cosh(st.pop));
			continue;
		}
        st.push(new Const(parseInt(cur)));
    }
    return st.pop();
}
