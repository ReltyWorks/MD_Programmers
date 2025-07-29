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
    public int solution(int n) {
        // 선언, 초기화
        int answer = 0;
        double doubleN = 0;
        List<int> primeNumbers = new List<int>();
        primeNumbers.Add(2);
        bool isContainedInPrimeNumbers = false;
        bool isCurrentNumberPrime = false;

        // 전체 루틴을 n만큼 반복하고 싶다.
        for (int i = 1; i < n; i++) {

            // 제곱근을 구한다.
            doubleN = i + 1;
            doubleN = Math.Sqrt(doubleN);

            // 제곱근이 정수로 떨어진다면, 소수가 아니다.
            if (doubleN % (int)doubleN == 0) continue;

            // 현재 수가 소수 컬렉션에 포함되어있나?
            isContainedInPrimeNumbers = primeNumbers.Contains(i);
            if (isContainedInPrimeNumbers) continue;

            // 소수 컬렉션으로 n의 인자 i를 검사한다.
            for (int ii = 0; ii < primeNumbers.Count; ii++) {

                // i를 소수 컬렉션의 인자로 나눠서 나머지가 없다면 소수가 아님, 다음 인자로
                if (i % primeNumbers[ii] == 0) continue;

                // 이번에 검사할 소수 컬렉션의 인자가 n의 제곱근보다 크면 반복문 종료.
                if (primeNumbers[ii] > doubleN) break;

                // ii를 

            }

            if (isCurrentNumberPrime && !primeNumbers.Contains(i)) primeNumbers.Add(i);
        }

        return answer;
    }
}
class Program {
    static void Main() {
        Solution solution = new Solution();

        int x = 10;

        Console.WriteLine(solution.solution(x));
    }
}