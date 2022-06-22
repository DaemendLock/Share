(ns linear.core
    (:require [clojure.set :as set])
	(:gen-class))

(defn v+ [v1 & vectors]
	(apply mapv + v1 vectors)
)	

(defn v- [v1 & vectors]
	(apply mapv - v1 vectors)
)

(defn v* [v1 & vectors]
	(apply mapv * v1 vectors)
)

(defn vd [v1 & vectors]
	(apply mapv / v1 vectors)
)

(defn v*s [v1 c]
	(mapv (fn [a] (* a c)) v1)
)

(defn scalar [& vectors]
	(apply + (apply v* vectors))
)

(defn m+ [m1 & vectors]
    (apply mapv v+ m1 vectors)
)

(defn m* [m1 & vectors]
    (apply mapv v* m1 vectors)
)

(defn m- [m1 & vectors]
    (apply mapv v- m1 vectors)
)

(defn md [m1 & vectors]
    (apply mapv vd m1 vectors)
)

(defn c+ [m1 & vectors]
    (apply mapv c+ m1 vectors)
)

(defn c* [m1 & vectors]
    (apply mapv c* m1 vectors)
)

(defn c- [m1 & vectors]
    (apply mapv c- m1 vectors)
)

(defn cd [m1 & vectors]
    (apply mapv cd m1 vectors)
)

(defn c*s [m1 c]
	(mapv (fn [a] (c*s a c)) m1)
)

(defn transpose [m1]
	(apply mapv vector m1)
)

(defn m*v [m1 & vectors] 
    (mapv (fn [x] (apply scalar x vectors)) m1)
)

(defn m*m [& vectors]
    (reduce (fn [a b] (mapv (fn [c] (m*v (transpose b) c)) a)) vectors)
)

(defn evalCord [v1 v2 step]
  (- (* (nth v1 step) (nth v1 (rem (+ step 1) 3))) (* (nth v2 step) (nth v2 (rem (+ step 1) 3))))
)

(defn vect [& vectors]
    (reduce (fn [a b] (vector (evalCord a b 1) (evalCord a b 2) (evalCord a b 0))) vectors)
)