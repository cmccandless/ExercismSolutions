import java.util.*;

public final class Sieve {
    private int max;
    public Sieve(int max) {
        this.max = max;
    }
    
    public List<Integer> getPrimes() {
        boolean[] np = new boolean[max + 1];
        ArrayList<Integer> p = new ArrayList();
        np[0] = np[1] = true;
        for (int i=2;i<np.length;i++) {
            if (np[i]) continue;
            p.add(i);
            for (int j=i+i;j<np.length;j+=i) np[j] = true;
        }
        return p;
    }
}