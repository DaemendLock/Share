(def vars {})
(def posvar ["x", "y", "z"])
(defn constant [a]
    (fn [arr] a)
)
(defn variable [a]
    (fn [arr] (if (and (> (count arr) 0) (= (count vars) 0)) (def vars arr) ())
    (vars a))
)

(defn add [a b] (fn [arr]
    (+ (a arr) (b arr))
)
)
(defn subtract [a b]
    (fn [arr]
    (- (a arr) (b arr))
    ) 
)
(defn multiply [a b]
   (fn [arr] 
   (* (a arr) (b arr))
   )
)
(defn divide [a b]
    (fn [arr] (/ (a arr) (b arr)))
)
(defn negate [a]
    (fn [arr]
    (- 0 (a arr)))
)

(defn step [x n]
     (if (zero? n) 1
         (* x (step x (dec n))))
)

(defn pow [a b]
    (fn [arr]
        (step (a arr) (b arr))
    )
)
(defn log [a b]
    (fn [arr]
        (/ (Math/log (Math/abs (b arr))) (Math/log (Math/abs (a arr))))))

(def opers {"(+" add, "(-" subtract, "(*" multiply, "(/" divide, "(-`" negate})
(defn parseFunction [str]
    (def pStr (clojure.string/split str #" "))
    (def cursor 0)
    (defn doNext []
        (def cur (get pStr cursor))
        (def cursor (+ cursor 1))
        (if (= cur ")")
        ()
        (if (contains? opers cur)
            (def res ((get opers cur) (doNext) (doNext)))
            (if (.contains posvar (subs cur 0 (max 1 (- (count cur) 1))))
                (def res (variable (subs cur 0 (max 1 (- (count cur) 1)))))
                (def res (constant (Integer/parseInt (subs cur 0 (max 1 (- (count cur) 1)))))))))
        res)
    (doNext))