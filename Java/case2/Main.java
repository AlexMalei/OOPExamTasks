import structures.Dictionary.TDictionary;
import structures.Dictionary.TPair;
import structures.*;

public class Main {
    private static void printList(TList<Integer> list) {
        for (int i = 0; i < list.getSize(); i++) {
            System.out.print(list.get(i) + ", ");
        }
        System.out.println("");

    }

    private static void printArray(TArray<Integer> array) {
        for (int i = 0; i < array.getSize(); i++) {
            Integer num = array.get(i);
            System.out.print((num == null ? 0 : num) + ", ");
        }
        System.out.println("");
    }

    private static void testList() {
        TList<Integer> list = new TList<>();
        for (int i = 1; i < 10; i++) {
            list.add(i);
        }

        list.remove(0);
        list.remove(0);

        printList(list);
        list.add(10);
        printList(list);
        list.add(0, 0);
        printList(list);

    }

    private static void testBitArray() {
        TBitArray bitArray = new TBitArray();
        bitArray.setElement(1, true);
        bitArray.setElement(2, true);
//        bitArray.setElement(3, true);

        System.out.println(bitArray.getElement(1));
        System.out.println(bitArray.getElement(2));
        System.out.println(bitArray.getElement(3));

//        bitArray.setElement(3, false);
//        System.out.println(bitArray.getElement(3));
    }

    private static void testCircularBuffer() {
        TCircularBuffer buffer = new TCircularBuffer(5);
        for (byte i = 0; i < 5; i++) {
            buffer.write(i);
        }
        buffer.read();
        buffer.write((byte) 5);
        buffer.increaseSize(1);
        buffer.write((byte) 6);


        while (!buffer.isEmpty()) {
            System.out.println("r: " + buffer.getReadPosition() + ", " + buffer.read());
        }
    }

    private static void testStack() {
        TStack<Integer> stack = new TStack<>();
        for (int i = 0; i < 5; i++) {
            stack.push(i);
        }

        for (int i = 0; i < 5; i++) {
            System.out.println(stack.pop());
        }
    }

    private static void testProcessorStack() {
        TProcessorStack processorStack = new TProcessorStack();
        processorStack.push(new byte[]{1, 2, 3});
        processorStack.newFrame();
        processorStack.push(new byte[]{1, 2, 3, 4});

        for (byte b : processorStack.pop(7)) {
            System.out.println(b + ", ");
        }
        System.out.println(processorStack.getCurrentFrameStartIndex());

    }

    private static void testArray() {
        TArray<Integer> a = new TArray<>(5);
        TArray<Integer> b = new TArray<>(1);

        for (int i = 0; i < 5; i++) {
            a.add(i);
        }
        a.add(-1, 0);
        a.removeAt(2);
        b.add(10);
        b.add(-20);
        a.copyTo(b, 1);
        b.sort((o1, o2) -> {
            int num1 = o1 == null ? 0 : o1;
            int num2 = o2 == null ? 0 : o2;
            return num1 - num2;
        });
        printArray(b);
    }

    private static void testMatrix() {
        TMatrix m1 = new TMatrix(2, 3);
        TMatrix m2 = new TMatrix(3, 4);

        m1.setElement(0, 0, 1);
        m1.setElement(0, 1, 3);
        m1.setElement(0, 2, 2);

        m1.setElement(1, 0, 0);
        m1.setElement(1, 1, 4);
        m1.setElement(1, 2, -1);

        m2.setElement(0, 0, 2);
        m2.setElement(0, 1, 0);
        m2.setElement(0, 2, -1);
        m2.setElement(0, 3, 1);

        m2.setElement(1, 0, 3);
        m2.setElement(1, 1, -2);
        m2.setElement(1, 2, 1);
        m2.setElement(1, 3, 2);

        m2.setElement(2, 0, 0);
        m2.setElement(2, 1, 1);
        m2.setElement(2, 2, 2);
        m2.setElement(2, 3, 3);

        m1.multiply(m2);
        m1.transpose();
        System.out.println("");
    }


    private static void printDictionary(TDictionary<String, Integer> dictionary) {
        for (TPair<String, Integer> pair : dictionary) {
            System.out.print(pair.getKey() + ":" + pair.getValue() + ", ");
        }
        System.out.println(dictionary.isSorted());
        System.out.println("");
    }

    private static void testDictionary() {
        TDictionary<String, Integer> dictionary = new TDictionary<>();
        dictionary.add("b", 1);
        dictionary.add("a", 100);
        dictionary.add("d", 1000);
        printDictionary(dictionary);
        dictionary.sort();
        printDictionary(dictionary);
        dictionary.set("a", 2);
        printDictionary(dictionary);
        dictionary.remove("a");
        printDictionary(dictionary);
    }

    public static void main(String[] args) {
        testArray();
    }
}
