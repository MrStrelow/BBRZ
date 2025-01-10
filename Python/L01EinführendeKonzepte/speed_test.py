import time

start = time.time()
size = 100000
s = [None] * size
for i in range(size):
    s[i] = str(i)
    
s = ''.join(s)

end = time.time()
print(f"Dauer: {(end - start) * 1000} ms")

# import time

# start = time.time()
# sum = 0
# for i in range(100000000):
#     sum += i

# end = time.time()
# print(f"Dauer: {(end - start) * 1000} ms")
# ```
# Dauer: 11039.769649505615 ms (inline)
# Dauer: 6971.364498138428 ms (py speed_test.py)