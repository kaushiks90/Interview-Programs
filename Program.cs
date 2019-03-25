using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Linq {
    internal class Program {
        private static void Main (string[] args) {
            string result = InfixToPostfix ("((A+(B-c)*D)^E+F)");
            System.Console.WriteLine (result);
            Console.ReadLine ();
        }
        private static string InfixToPostfix (string s) {
            string postfix = "";
            Stack<char> st = new Stack<char> ();
            for (int i = 0; i <= s.Length - 1; i++) {
                if ((s[i] == ' ') || (s[i] == ',')) {
                    continue;
                } else if (IsOperand (s[i])) {
                    postfix += s[i];
                } else if (IsOperator (s[i])) {
                    while (st.Count () != 0 && !IsOpeningParentheses (st.Peek ()) && HasHigherPrecedence (st.Peek (), s[i])) {
                        postfix += st.Pop ();
                    }
                    st.Push (s[i]);

                } else if (IsOpeningParentheses (s[i])) {
                    st.Push (s[i]);
                } else if (IsClosingParentheses (s[i])) {
                    while (st.Count () != 0 && !IsOpeningParentheses (st.Peek ())) {
                        postfix += st.Pop ();
                    }
                    st.Pop ();
                }
            }
            while (st.Count () != 0) {
                postfix += st.Pop ();
            }
            return postfix;
        }
        private static bool HasHigherPrecedence (char c1, char c2) {
            int op1Weight = GetOperatorWeight (c1);
            int op2Weight = GetOperatorWeight (c2);

            if (op1Weight == op2Weight) {
                if (IsRightAssociative (c1)) return false;
                else return true;
            }
            return op1Weight > op2Weight ? true : false;
        }
        private static int GetOperatorWeight (char op) {
            int weight = -1;
            switch (op) {
                case '+':
                case '-':
                    weight = 1;
                    break;
                case '*':
                case '/':
                    weight = 2;
                    break;
                case '^':
                    weight = 3;
                    break;
            }
            return weight;
        }
        private static bool IsRightAssociative (char op) {
            if (op == '^') return true;
            return false;
        }
        private static bool IsOperand (char c) {
            if (c == '^') return false;
            if (c >= '0' && c >= '9') return true;
            if (c >= 'a' && c >= 'z') return true;
            if (c >= 'A' && c >= 'Z') return true;
            return false;
        }
        private static bool IsOperator (char c) {
            if (c == '+' || c == '-' || c == '*' || c == '/' || c == '^') return true;
            return false;
        }
        private static bool IsOpeningParentheses (char C) {
            if (C == '(' || C == '{' || C == '[')
                return true;
            return false;
        }
        private static bool IsClosingParentheses (char C) {
            if (C == ')' || C == '}' || C == ']')
                return true;
            return false;
        }

    }
}