res = 10

# for n in [1,2,3,4]:
for n in range(1,5):
    res += n # 11 13 16 20

print(res)


def zaehle_dazu(n, res):
    if n == 5:
        return res

    return zaehle_dazu(n+1, res + n)


print(zaehle_dazu(1, 10))