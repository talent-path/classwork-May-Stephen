public class LeetCode {
    public static void main(String[] args) {

        int[] nums = {3, 2, 4};
        int target = 6;
        System.out.println(twoSum(nums, target));

    }

    public static int[] twoSum(int[] nums, int target) {
        int[] output = {0,0};

            for (int i = 0; i < nums.length - 1; i++) {
                for (int j = 1; j < nums.length - 1; j++) {
                    if (nums[i] + nums[j] == target) {
                        output[0] = i;
                        output[1] = j;
                    }
                }
                return output;
            }

        System.out.println(output);
        return output;
    }
}
