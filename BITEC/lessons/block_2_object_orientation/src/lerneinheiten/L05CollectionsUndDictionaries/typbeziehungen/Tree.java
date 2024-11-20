package lerneinheiten.L05CollectionsUndDictionaries.typbeziehungen;

import java.util.*;

public class Tree<T> implements Iterable<T> {
    static class TreeNode<T> {
        T value;
        List<TreeNode<T>> children;

        public TreeNode(T value) {
            this.value = value;
            this.children = new ArrayList<>();
        }

        public void addChild(TreeNode<T> child) {
            children.add(child);
        }
    }

    private final TreeNode<T> root;

    public Tree(T rootValue) {
        this.root = new TreeNode<>(rootValue);
    }

    public TreeNode<T> getRoot() {
        return root;
    }

    public TreeNode<T> addChild(TreeNode<T> parent, T childValue) {
        TreeNode<T> child = new TreeNode<>(childValue);
        parent.addChild(child);
        return child;
    }

    @Override
    public Iterator<T> iterator() {
        return new DFSIterator<>(root);
    }

    // Depth-First Search Iterator
    private static class DFSIterator<T> implements Iterator<T> {
        private final Stack<TreeNode<T>> stack;

        public DFSIterator(TreeNode<T> root) {
            stack = new Stack<>();
            if (root != null) {
                stack.push(root);
            }
        }

        @Override
        public boolean hasNext() {
            return !stack.isEmpty();
        }

        @Override
        public T next() {
            if (!hasNext()) {
                throw new NoSuchElementException();
            }
            TreeNode<T> current = stack.pop();
            List<TreeNode<T>> children = current.children;
            for (int i = children.size() - 1; i >= 0; i--) {
                stack.push(children.get(i));
            }
            return current.value;
        }
    }
}
