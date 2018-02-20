import java.util.*;

public class TwoBucket {
    private class BucketState {
        public int[] buckets;
        public int count;
        public String key;
        public BucketState(int[] buckets, int count) {
            this.buckets = buckets;
            this.count = count;
            this.key = String.format("%d,%d", buckets[0], buckets[1]);
        }
        public int indexOf(int goal) {
            for (int i = 0; i < buckets.length; i++) {
                if (buckets[i] == goal) return i;
            }
            return -1;
        }
        public BucketState empty(int i) {
            return new BucketState(
                i == 0 ?
                    new int[] {0, buckets[1]} :
                    new int[] {buckets[0], 0},
                count + 1
            );
        }
        public BucketState fill(int i) {
            return new BucketState(
                i == 0 ?
                    new int[] {sizes[0], buckets[1]} :
                    new int[] {buckets[0], sizes[1]},
                count + 1
            );
        }   
        public BucketState consolidate(int i) {
            int amount = Math.min(
                buckets[1 - i],
                sizes[i] - buckets[i]
            );
            int target = buckets[i] + amount;
            int src = buckets[1 - i] - amount;
            return new BucketState(
                i == 0 ? 
                    new int[] {target, src} :
                    new int[] {src, target},
                count + 1
            );
        }
    }

    private int[] sizes;
    private int goal;
    private BucketState state;
    public TwoBucket(int firstBucket, int secondBucket,
                     int goal, String startBucket) {
        this.goal = goal;
        this.sizes = new int[] {firstBucket, secondBucket};
        Queue<BucketState> toVisit = new LinkedList<>();
        Set<String> visited = new HashSet<>();
        state = new BucketState(new int[2], 0);
        if (startBucket == "one") {
            visited.add(String.format("0,%d", secondBucket));
            state = state.fill(0);
        } else {
            visited.add(String.format("%d,0", firstBucket));
            state = state.fill(1);
        }
        while (state.indexOf(goal) < 0) {
            if (!visited.contains(state.key)) {
                visited.add(state.key);
                for (int i = 0; i < 2; i++) {
                    if (state.buckets[i] != 0)
                        toVisit.offer(state.empty(i));
                    if (state.buckets[i] != sizes[i]) {
                        toVisit.offer(state.fill(i));
                        if (state.buckets[1 - i] != 0)
                            toVisit.offer(state.consolidate(i));
                    }
                }
            }
            state = toVisit.poll();
        }
    }
    public int getTotalMoves() {
        return state.count;
    }
    public int getOtherBucket() {
        return state.buckets[1 - state.indexOf(goal)];
    }
    public String getFinalBucket() {
        switch(state.indexOf(goal)) {
            case 0: return "one";
            case 1: return "two";
            default: return "none";
        }
    }
}
