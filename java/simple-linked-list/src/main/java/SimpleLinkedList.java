import java.util.*;
import java.lang.reflect.*;

public final class SimpleLinkedList {
    private final class Node {
        public Integer value;
        public Node next;
        public Node(int v) { value = v; }
        public int size() {
            return next == null ? 1 : 1 + next.size();
        }
    }
    private Node head = null;
    public SimpleLinkedList() { }
    public SimpleLinkedList(Integer[] values) {
        for (Integer v : values) push(v);
    }
    public int size() { return head == null ? 0 : head.size(); }
    public void push(int x) {
        Node n = new Node(x);
        n.next = head;
        head = n;
    }
    public int pop() {
        if (head == null) throw new NoSuchElementException();
        Node n = head;
        head = n.next;
        return n.value;
    }
    public <T> T[] asArray(Class<T> c) {
        int s = size();
        @SuppressWarnings("unchecked")
        T[] a = (T[])Array.newInstance(c, s);
        for (Node n = head; n != null; n = n.next) {
            a[s-n.size()] = (T)n.value;
        }
        return a;
    }
    public void reverse() {
        Queue<Integer> a = new LinkedList<Integer>();
        while (size() > 0) a.offer(pop());
        while (!a.isEmpty()) push(a.poll());
    }
}
