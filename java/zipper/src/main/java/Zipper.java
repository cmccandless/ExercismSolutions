public class Zipper {
    private int value;
    public Zipper up;
    public Zipper left;
    public Zipper right;
    public Zipper(int value) {
        this.value = value;
    }
    public BinaryTree toTree() {
        if (this.up == null) {
            return new BinaryTree(this);
        }
        return this.up.toTree();
    }
    public void setRight(Zipper right) {
        this.right = right;
        if (right != null) {
            right.up = this;
        }
    }
    public void setLeft(Zipper left) {
        this.left = left;
        if (left != null) {
            left.up = this;
        }
    }
    public void setValue(int value) {
        this.value = value;
    }
    public int getValue() {
        return this.value;
    }
    @Override
    public boolean equals(Object o) {
        if (o == this) {
            return true;
        }

        if (!(o instanceof Zipper)) {
            return false;
        }

        Zipper other = (Zipper)o;

        return this.value == other.value &&
            this.up == other.up &&
            this.left == other.left &&
            this.right == other.right;
    }
    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append("value: ");
        sb.append(Integer.toString(this.value));
        sb.append(", left: ");
        if (this.left == null) {
            sb.append("null");
        } else {
            sb.append("{ ");
            sb.append(this.left.toString());
            sb.append(" }");
        }
        sb.append(", right: ");
        if (this.right == null) {
            sb.append("null");
        } else {
            sb.append("{ ");
            sb.append(this.right.toString());
            sb.append(" }");
        }
        return sb.toString();
    }
}
