def say_hello(wort):
    print(f"Hallo {wort}")


def pre_und_post_print(mach_nur_post):
    def decorator(func):
        def wrapper(arg_for_function):
            if not mach_nur_post:
                print("PRE")
            
            func(arg_for_function)

            print("POST")

        return wrapper
    
    return decorator


decorator = pre_und_post_print(mach_nur_post=True)
wrapper = decorator(say_hello)
wrapper("du")