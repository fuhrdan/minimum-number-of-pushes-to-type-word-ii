int minimumPushes(char* word) {
    int nums[130] = {0};
    int retMin = 0;
    int maxnum = 0;
    int min = 1000;
    for(int i = 0; i < strlen(word); i++)
    {
        int map = word[i];
        if(min > map) min = map;
        if(map > maxnum) maxnum = map;
        nums[map]++;
//        printf("word[%d] = %c count at %d\n",i,word[i],nums[map]);
    }
    /*
    for(int j = min; j <= maxnum; j++)
    {
        for(int i = min; i <= maxnum; i++)
        {
            if(nums[j] > nums[i])
            {
                int temp = nums[i];
                nums[i] = nums[j];
                nums[j] = temp;
            }
        }
    }
*/
    for (int j = min; j < maxnum; j++) {
        for (int i = min; i < maxnum - (j - min); i++) {
            if (nums[i] < nums[i + 1]) {
                int temp = nums[i];
                nums[i] = nums[i + 1];
                nums[i + 1] = temp;
            }
        }
    }
    int multiple = 1;
    int count = 0;
    for (int j = min; j <= maxnum; j++) 
    {
        if (nums[j] > 0) {
            retMin += nums[j] * multiple;
            count++;
            if (count == 8) {
                multiple++;
                count = 0;
            }
        }
//        printf("%d retMin = %d (count = %d, multiple = %d\n",j-min,retMin,count,multiple);
    }
    return retMin;
}
