public class BinaryTree {
    private Zipper root;
    public BinaryTree(int value) {
        this(new Zipper(value));
    }
    public BinaryTree(Zipper root) {
        this.root = root;
    }
    public Zipper getRoot() {
        return this.root;
    }
    public String printTree() {
        return this.root.toString();
    }
    @Override
    public boolean equals(Object o) {
        if (o == this) {
            return true;
        }

        if (!(o instanceof BinaryTree)) {
            return false;
        }

        BinaryTree other = (BinaryTree)o;

        return this.root == other.root;
    }
    @Override
    public String toString() {
        return this.printTree();
    }
}
