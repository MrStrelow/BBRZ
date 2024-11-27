package lerneinheiten.L05CollectionsUndDictionaries.baum;

public class TreeExample {
    public static void main(String[] args) {
        Tree<String> tree = new Tree<>("Root");

        Tree.TreeNode<String> root = tree.getRoot();
        Tree.TreeNode<String> child1 = tree.addChild(root, "Child 1");
        Tree.TreeNode<String> child2 = tree.addChild(root, "Child 2");
        Tree.TreeNode<String> child3 = tree.addChild(root, "Child 3");

        tree.addChild(child1, "Child 1.1");
        tree.addChild(child1, "Child 1.2");

        tree.addChild(child2, "Child 2.1");
        tree.addChild(child2, "Child 2.2");
        tree.addChild(child2, "Child 2.3");

        tree.addChild(child3, "Child 3.1");

        // Use a for-each loop to traverse the tree
        for (String value : tree) {
            System.out.println(value);
        }
    }
}
