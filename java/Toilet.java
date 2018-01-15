import java.util.Scanner;

public class Toilet {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        char[] prefs = sc.next().toCharArray();

        int a = 0, b = 0, c = 0;

        for (int i = 1; i < prefs.length; i++) {
            a += Toilet.first(i == 1 ? prefs[i-1] : 'U', prefs[i]);
            b += Toilet.second(i == 1 ? prefs[i-1] : 'D', prefs[i]);
            c += Toilet.third(prefs[i-1], prefs[i]);
        }

        System.out.println(a);
        System.out.println(b);
        System.out.print(c);
    }

    public static int first(char status, char pref) {
        int count = 0;

        if (status == 'U') {
            if (pref == 'D') {
                count = 2;
            }
        } else {
            count = 1;
        }

        return count;
    }

    public static int second(char status, char pref) {
        int count = 0;

        if (status == 'D') {
            if (pref == 'U') {
                count = 2;
            }
        } else {
            count = 1;
        }

        return count;
    }

    public static int third(char status, char pref) {
        int count = 0;

        if (status == pref) {
            count = 0;
        } else {
            count = 1;
        }

        return count;
    }
}