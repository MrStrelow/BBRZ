# Regex in an Editor

## 1. Using Regex to Search and Replace in VS Code
VS Code supports regex-based search and replace. To enable regex mode, click the `.*` button in the search bar.

### Example:
- **Search for all email addresses**: `\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b`
- **Replace domain**: Use `@(old-domain)\.com` and replace with `@new-domain.com`.

---

## 2. Recognizing an Email Address
A simple regex pattern for recognizing email addresses:
```
[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}
```
### Explanation:
- `A-Za-z0-9._%+-` → Matches valid characters before `@`.
- `@` → Matches the `@` symbol.
- `[A-Za-z0-9.-]+` → Matches domain name characters.
- `\.` → Matches the dot before the domain suffix.
- `[A-Za-z]{2,}` → Matches domain suffix (e.g., `com`, `org`).

---

## 3. Common Regex Functions
### 3.1 `findall()`
Finds all matches in a string.
```python
import re
text = "Emails: test@example.com, user@mail.com"
print(re.findall(r'\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b', text))
```

### 3.2 `sub()` (Replace)
Replaces matched patterns.
```python
replaced_text = re.sub(r'@example\.com', '@new.com', "Contact: test@example.com")
print(replaced_text)
```

### 3.3 `search()`
Finds the first match.
```python
match = re.search(r'\d+', "Order 1234")
print(match.group() if match else "No match")
```

### 3.4 `split()`
Splits a string based on a pattern.
```python
words = re.split(r'\s+', "Hello   World!")
print(words)
```

---

## 4. Regex Shortcuts and Abbreviations
- `\d` → Digits (0-9)
- `\D` → Non-digits
- `\w` → Word characters (letters, digits, underscore)
- `\W` → Non-word characters
- `\s` → Whitespace (space, tab, newline)
- `\S` → Non-whitespace
- `.` → Any character (except newline)

---

## 5. Regex Parts and Symbols
### 5.1 Brackets `[]` vs Parentheses `()`
- `[]` → Character sets: `[a-z]` matches any lowercase letter.
- `()` → Groups: `(abc|xyz)` matches either `abc` or `xyz`.

### 5.2 Anchors `^` and `$`
- `^` → Start of a string: `^Hello` matches only if it starts with `Hello`.
- `$` → End of a string: `World!$` matches only if it ends with `World!`.

### 5.3 Greedy `*` vs Non-Greedy `*?`
- `.*` → Matches everything (greedy)
- `.*?` → Matches as little as possible (non-greedy)

#### Example:
```python
text = "<title>Hello</title><title>World</title>"
print(re.findall(r'<title>.*</title>', text))  # Greedy, captures everything
print(re.findall(r'<title>.*?</title>', text)) # Non-greedy, captures separately
```