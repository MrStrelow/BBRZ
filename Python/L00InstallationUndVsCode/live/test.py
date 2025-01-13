import time

start = time.time()
sum = 0
for i in range(100000000):
    sum += i

end = time.time()

print(f"Dauer: {(end - start) * 1000} ms")

def hello(a):
    print("hello")


hello()
hello()
hello()
hello()
hello()
hello()

