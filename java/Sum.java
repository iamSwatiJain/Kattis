import java.util.Scanner;

public class Sum {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int gunnar = Sum.getTotalCount(sc.nextInt(), sc.nextInt(), sc.nextInt(), sc.nextInt());
        int emma = Sum.getTotalCount(sc.nextInt(), sc.nextInt(), sc.nextInt(), sc.nextInt());

        if(gunnar>emma){
            System.out.print("Gunnar");
        } else if(emma>gunnar){
            System.out.print("Emma");
        } else{
            System.out.print("Tie");
        }
    }

    public static int getTotalCount(int a1, int b1, int a2, int b2) {
        return a1+b1+a2+b2;
    }

}