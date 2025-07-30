/*
※ 연습문제 > 소수 찾기

[문제 설명]
1부터 입력받은 숫자 n 사이에 있는 소수의 개수를 반환하는
함수, solution을 만들어 보세요.
소수는 1과 자기 자신으로만 나누어지는 수를 의미합니다.
(1은 소수가 아닙니다.)

[제한 사항]
※ n은 2이상 1000000이하의 자연수입니다.

[입출력]
n       result
10      4
5       3

[유의사항]
*/

#region 생각
/*
문제는 소수, 어렵게 생각하지말고 나눠지지 않는 수를 생각해보자
어떤 수 n은.. 그러니까.. a * b로 표현 할 수 있다.
16을 예로 들면, 4*4, 8*2, 2*8 정도가 나온다.
n = a * b 일 때, a, b는 n보다 작을 것
그리고 16의 예로 돌아가면, 4를 기준으로, 시소처럼 a, b가 대칭인 식이 나온다.
4는 16의 제곱근(학교다닐때 배운다고 하는데 난 기억이 안난다..)
그러니까 제곱해서 n이 되는 수는 n의 제곱근이 된다.

그리고, 16을 8로 나눌 필요가 없다.
8은 2로 나눠지니까 2로만 나눠보면 된다.
마찬가지로, 6이나 10도 나눠볼 필요가 없다.
6은 3이, 10은 5가 처리해 줄 테니까
그럼 소수로만 나눠보면 되나?
느낌적인 느낌으로 그런거 같다.
맞지, 나눠지지 않는걸 찾는데,
3으로 나누면 6은 검사할 필요없다.
즉, 소수로만 검사해보면 된다.

그렇다면 n이 소수인지 알아보려면
소수로만 나눠보면 된다는 결론이 나온다.
제곱근이 시소의 중앙 역할을 하니까
제곱근까지만 나눠보면 될테지.
그 뒤로는 앞뒤 자리만 바뀌어 있을테니까.

더 중요한건, 제곱근을 구했을때 나머지가 없다면 그것도 소수가 아니다.
*/
#endregion

using System;
using System.Collections.Generic;

public class Solution {
    List<int> primeNumbers = new List<int>(); // (수정)
    public int solution(int n) {
        // 선언, 초기화
        List<int> primeNumbers = new List<int>();
        bool isContainedInPrimeNumbers = false;
        bool isCurrentNumberPrime = true;

        // 일단 2라도 있어야 돌아감 (수정)
        if (!primeNumbers.Contains(2)) primeNumbers.Add(2);

        // 전체 루틴을 n만큼 반복하고 싶다.
        for (int i = 2; i <= n; i++) {

            // 검사 시작 전, 일단 현재 숫자를 "소수일 것이다"라고 가정한다.
            isCurrentNumberPrime = true;

            // 제곱근을 구한다.
            double doubleN = Math.Sqrt(i);

            // 2. 이미 찾은 소수들로만 나누어 본다. (foreach로 가독성을 높였어)
            foreach (int prime in primeNumbers) {

                // 3. 나누어 떨어지면 소수가 아니다!
                if (i % prime == 0) {
                    isCurrentNumberPrime = false; // "소수가 아니다"라고 확정!
                    break; // 4. 더 이상 검사할 필요가 없으므로 즉시 안쪽 반복문 탈출 (핵심!)
                }

                // 5. 검사할 소수가 현재 수의 제곱근보다 크면 더 볼 필요가 없다. (원래 있던 좋은 로직!)
                if (prime > doubleN) {
                    break;
                }
            }
            // 6. 위 반복문의 모든 검사를 통과했다면 (isPrime이 여전히 true라면) 진짜 소수다.
            if (isCurrentNumberPrime) {
                primeNumbers.Add(i);
            }
        }
        return primeNumbers.Count;
    }
}
class Program {
    static void Main() {
        Solution solution = new Solution();

        int x = 100;
        int y = 1000;

        Console.WriteLine(solution.solution(x));
        Console.WriteLine(solution.solution(y));
    }
}

// 변수값을 이쁘게 적으라고 해서 그렇게 했는데,
// 이렇게 길어지니까 진짜 노답인데?
// 시간 초과가 떳다... 에반데? 일단 저장
// 시간 초과가 떠서 primeNumbers을 함수 밖으로 빼봤다.. 소수는 계속 가지고 가게..
// 결국 잼민이의 도움을 받았다. 알고리즘, 효율.