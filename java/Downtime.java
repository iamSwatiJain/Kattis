import java.io.IOException;

public class Downtime {
    private static int nextInt() throws IOException {
        int res = 0;
        boolean digit = false;
        for (int c = 0; (c = System.in.read()) != -1; ) {
            if (c >= '0' && c <= '9') {
                digit = true;
                res = res * 10 + c - '0';
            } else if (digit) {
                break;
            }
        }
        return res;
    }

    public static void main(String[] args) throws IOException {
        long startTime = System.currentTimeMillis();

        //InputReader sc = new InputReader(System.in);

        int n = Downtime.nextInt();
        int k = Downtime.nextInt();

        int[] reqs = new int[n];

        for(int i = 0; i < n; i++) {
            int req = Downtime.nextInt();

            for (int j = 0; j < n; j++) {
                if (reqs[j] <= req) {
                    reqs[j] = req + 1000;

                    break;
                }
            }
        }

        int p = 0;
        for (int req : reqs) {
            //System.out.println("L: " + req);
            if (req > 0) {
                p++;
            }
        }

        System.out.printf("%.0f", Math.ceil(p/ (double)k));
        //System.out.println((System.currentTimeMillis() - startTime));
    }
}
