public class DoublyLinkedList<T> {
    private class Node {
        public T value;
        public Node prev;
        public Node next;
    }
    private Node head, tail;
    public void push(T v) {
        Node n = new Node() {{value = v; prev = tail;}};
        if (tail != null) tail.next = n;
        tail = n;
        if (head == null) head = n;
    }
    public void unshift(T v) {
        Node n = new Node() {{value = v; next = head;}};
        if (head != null) head.prev = n;
        head = n;
        if (tail == null) tail = n;
    }
    public T pop() {
        T v = tail.value;
        tail = tail.prev;
        if (tail != null) tail.next = null;
        return v;
    }
    public T shift() {
        T v = head.value;
        head = head.next;
        if (head != null) head.prev = null;
        return v;
    }
}
