import java.util.*;

public final class BST<TOuter extends Comparable<TOuter>> {
    public static class Node<TInner extends Comparable<TInner>> {
        TInner data;
        Node<TInner> right, left;
        public Node(TInner x) { this.data = x; }
        public TInner getData() { return data; }
        public Node<TInner> getRight() { return right; }
        public void setRight(Node<TInner> n) { right = n; }
        public Node<TInner> getLeft() { return left; }
        public void setLeft(Node<TInner> n) { left = n; }
        public List<TInner> sorted() {
            List<TInner> result = new ArrayList<TInner>();
            if (left != null) result.addAll(left.sorted());
            result.add(data);
            if (right != null) result.addAll(right.sorted());
            return result;
        }
    }
    private Node<TOuter> root;
    public Node<TOuter> getRoot() { return root; }
    public void insert(TOuter x) {
        Node<TOuter> newNode = new Node<TOuter>(x), parent = null, current = root;
        boolean useRight = false;
        while (current != null) {
            current = (useRight = x.compareTo((parent = current).getData()) > 0) ? 
                parent.getRight() : 
                parent.getLeft();
        }
        if (parent == null) root = newNode;
        else if (useRight) parent.setRight(newNode);
        else parent.setLeft(newNode);
    }
    public List<TOuter> getAsSortedList() {
        return root == null ? new ArrayList<TOuter>() : root.sorted();
    }
    public List<TOuter> getAsLevelOrderList() {
        Queue<Node<TOuter>> q = new LinkedList<Node<TOuter>>();
        q.offer(root);
        List<TOuter> result = new ArrayList<TOuter>();
        while (!q.isEmpty()) {
            Node<TOuter> n = q.poll();
            if (n == null) continue;
            result.add(n.getData());
            q.offer(n.getLeft());
            q.offer(n.getRight());
        }
        return result;
    }
}
