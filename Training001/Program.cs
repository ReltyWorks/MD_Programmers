/*
※ 연습문제 > 옹알이(2)

[문제 설명]
머쓱이는 태어난 지 11개월 된 조카를 돌보고 있습니다.
조카는 아직 "aya", "ye", "woo", "ma" 네 가지 발음과
네 가지 발음을 조합해서 만들 수 있는 발음밖에 하지 못하고
연속해서 같은 발음을 하는 것을 어려워합니다.
문자열 배열 babbling이 매개변수로 주어질 때,
머쓱이의 조카가 발음할 수 있는 단어의 개수를
return하도록 solution 함수를 완성해주세요.

[제한 사항]
※ 1 ≤ babbling의 길이 ≤ 100
※ 1 ≤ babbling[i]의 길이 ≤ 30
※ 문자열은 알파벳 소문자로만 이루어져 있습니다.

[입출력]
babbling                                        result
["aya", "yee", "u", "maa"]                      1
["ayaye", "uuu", "yeye", "yemawoo", "ayaayaa"]  2

[유의사항]
네 가지를 붙여 만들 수 있는 발음 이외에는
어떤 발음도 할 수 없는 것으로 규정합니다.
예를 들어 "woowo"는 "woo"는 발음할 수 있지만
"wo"를 발음할 수 없기 때문에 할 수 없는 발음입니다.
*/

using System;

public class Solution {
    public int solution(string[] babbling) {

        int answer = 0;

        // 일단, 배열 babbling 만큼 반복
        for (int i = 0; i < babbling.Length; i++) {

            // 배열 babbling의 인자를
            // 하나씩 temp에 넣고 검사
            string temp = babbling[i];

            // check를 이용해서 검사결과를 저장
            int check = 0;

            // 단어를 연속해서 검사하지 않기위해
            int beforeCheck = 0;

            // 검사를 하는 반복문 시작
            for (int ii = 0; ii < temp.Length; ii++) {

                // 검사 방식은, ii에서 첫 글자를 검사하고
                // 그 다음 ii+1, ii+2에서 두, 세번째 검사
                // 만약 맞다면, check에서 해당하는 인자를 true
                // 그 다음 ii를 검사한 글자 수 만큼 점프

                // 검사 시작 조건은
                // 1. 첫 글자가 같은가?
                // 2. 이전 체크에서 검사한건 아닌가?
                // 3. 검사 중 단어의 최대길이를 넘어가진 않는가?

                // "aya"에 대한 검사
                if (temp[ii] == 'a' && beforeCheck != 1 && (ii + 2 <= temp.Length - 1)) {
                    if (temp[ii + 1] == 'y') {
                        if (temp[ii + 2] == 'a') {
                            check += 3;
                            beforeCheck = 1;
                            ii++;
                            ii++;
                        }
                    }
                }

                // "ye"에 대한 검사
                else if (temp[ii] == 'y' && beforeCheck != 2 && (ii + 1 <= temp.Length - 1)) {
                    if (temp[ii + 1] == 'e') {
                        check += 2;
                        beforeCheck = 2;
                        ii++;
                    }
                }

                // "yee"에 대한 검사
                else if (temp[ii] == 'w' && beforeCheck != 3 && (ii + 2 <= temp.Length - 1)) {
                    if (temp[ii + 1] == 'o') {
                        if (temp[ii + 2] == 'o') {
                            check += 3;
                            beforeCheck = 3;
                            ii++;
                            ii++;
                        }
                    }
                }

                // "ma"에 대한 검사
                else if (temp[ii] == 'm' && beforeCheck != 4 && (ii + 1 <= temp.Length - 1)) {
                    if (temp[ii + 1] == 'a') {
                        check += 2;
                        beforeCheck = 4;
                        ii++;
                    }
                }

                else beforeCheck = 0;

            }
            // 검사 반복문 끝

            // 검사결과가 맞다면?
            if (check == temp.Length) {
                answer++;
            }
        }

        return answer;
    }
}
class Program {
    static void Main() {
        string[] x = { "ayaye", "uuu", "yeye", "yemawoo", "ayaayaa" };
        Solution solution = new Solution();
        Console.WriteLine(solution.solution(x));
    }
}

// ※ 프로그래머스는 첨이라.. 다른 클래스를 써도 되나!?
// ※ 변수명에 좀 더 신경쓸것!
// ※ 줄이기 보단 기능 위주로 가독성 있게 만들것
// ※ 기능은 좋았으나, 좀 더 재활용 가능한 코드를 짜보자