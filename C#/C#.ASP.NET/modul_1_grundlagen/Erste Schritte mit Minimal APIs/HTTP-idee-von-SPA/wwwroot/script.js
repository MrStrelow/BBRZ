// Wartet, bis das HTML-Dokument vollständig geladen ist.
document.addEventListener('DOMContentLoaded', () => {
    const todoList = document.getElementById('todo-list');
    const addTodoForm = document.getElementById('add-todo-form');
    const newTodoTitleInput = document.getElementById('new-todo-title');

    // --- FUNKTIONEN ZUR INTERAKTION MIT DER API ---

    // Holt alle To-Dos vom Server und zeigt sie an.
    async function loadTodos() {
        const response = await fetch('/api/todos');
        const todos = await response.json();

        todoList.innerHTML = ''; // Leert die alte Liste
        todos.forEach(todo => {
            const li = createTodoElement(todo);
            todoList.appendChild(li);
        });
    }

    // Löscht ein To-Do.
    async function deleteTodo(todo) {
        if (!confirm('Wirklich löschen?')) return;
        const response = await fetch(`/api/todos/${todo.id}`, { method: 'DELETE' });
        if (response.ok) {
            document.getElementById(`todo-${todo.id}`).remove();
        } else {
            alert('Fehler beim Löschen.');
        }
    }

    // Bearbeitet ein To-Do.
    async function editTodo(todo) {
        const newTitle = prompt('Neuen Titel eingeben:', todo.title);
        if (newTitle && newTitle.trim() !== '') {
            console.log(todo.id)
            const response = await fetch(`/api/todos/${todo.id}`, {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ id: todo.id, title: newTitle.trim() })
            });
            
            if (response.ok) {
                document.getElementById(`todo-title-${todo.id}`).textContent = newTitle.trim();
            } else {
                alert('Fehler beim Bearbeiten.');
            }
        }
    }

    // --- HILFSFUNKTION ---

    // Erstellt ein einzelnes HTML-Listenelement für ein To-Do.
    function createTodoElement(todo) {
        const li = document.createElement('li');
        li.id = `todo-${todo.id}`;

        const titleSpan = document.createElement('span');
        titleSpan.id = `todo-title-${todo.id}`;
        titleSpan.textContent = todo.title;
        li.appendChild(titleSpan);

        const actionsDiv = document.createElement('div');
        actionsDiv.className = 'actions';

        const editButton = document.createElement('button');
        editButton.className = 'edit-btn';
        editButton.textContent = 'Bearbeiten';
        editButton.onclick = () => editTodo(todo);
        actionsDiv.appendChild(editButton);

        const deleteButton = document.createElement('button');
        deleteButton.className = 'delete-btn';
        deleteButton.textContent = 'Löschen';
        deleteButton.onclick = () => deleteTodo(todo);
        actionsDiv.appendChild(deleteButton);

        li.appendChild(actionsDiv);
        return li;
    }

    // --- EVENT LISTENER ---

    // Reagiert auf das Absenden des "Hinzufügen"-Formulars.
    addTodoForm.addEventListener('submit', async (e) => {
        e.preventDefault(); // Verhindert das Neuladen der Seite.
        const title = newTodoTitleInput.value.trim();
        if (!title) return;

        const response = await fetch('/api/todos', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ title: title })
        });

        if (response.ok) {
            const newTodo = await response.json();
            const li = createTodoElement(newTodo);
            todoList.appendChild(li);
            newTodoTitleInput.value = ''; // Leert das Eingabefeld.
        } else {
            alert('Fehler beim Hinzufügen.');
        }
    });

    // --- INITIALER AUFRUF ---

    // Lädt die To-Dos, wenn die Seite zum ersten Mal geöffnet wird.
    loadTodos();
});
