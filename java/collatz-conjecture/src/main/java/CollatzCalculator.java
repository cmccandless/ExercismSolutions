class CollatzCalculator {

    int computeStepCount(int start) {
        if (start < 1) throw new IllegalArgumentException("Only natural numbers are allowed");
        int c;
        for (c = 0; start != 1; c++) {
            if (start % 2 == 0) start /= 2;
            else start = 3 * start + 1;
        }
        return c;
    }

}
