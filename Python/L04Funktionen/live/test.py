import functools
import time

def timing_decorator(func):
    """Decorator to measure execution time of a function."""

    @functools.wraps(func)
    def wrapper(*args, **kwargs):
        start_time = time.perf_counter()

        result = func(*args, **kwargs)

        end_time = time.perf_counter()

        print(f"⏱ Execution time for {func.__name__}({args}): {end_time - start_time:.10f} seconds")

        return result
    
    return wrapper


@functools.lru_cache(maxsize=128)
def fibonacci_cached(n):
    """Compute Fibonacci with LRU caching."""
    if n < 2:
        return n
    
    return fibonacci_cached(n-1) + fibonacci_cached(n-2)


def fibonacci_uncached(n):
    """Compute Fibonacci without caching."""
    if n < 2:
        return n
    
    return fibonacci_uncached(n-1) + fibonacci_uncached(n-2)


@timing_decorator
def fibonacci(n, cached=True):
    if cached:
        return fibonacci_cached(n)

    else:
        return fibonacci_uncached(n)
    

# Mit Caching
# n = 10
# n = 20
# n = 30
n = 40
print("\n🔵 Running cached Fibonacci:")
print(fibonacci(n, cached=True)) # 0.0000776000 seconds

# Ohne Caching
print("\n🔴 Running uncached Fibonacci:") 
print(fibonacci(n, cached=False)) # 13.9514158000 seconds