using AvailityHomework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Availity_Test.Models
{
    public class Parentheses : IParentheses
    {
        public bool HasValidParenPairs(string myString)
        {
            // increment or decrement a variable
            int parens = 0;

            foreach (char character in myString)
            {

                if (character == '(')
                {
                    parens++; // add one for a left paren
                }
                if (character == ')')
                {
                    if (parens == 0)
                    {
                        // if a right paren comes before a left paren, then it's not a valid pair -- short circuit
                        return false;
                    }

                    parens--; // subtract one for a right paren
                }
            }

            // no straggler parens left in stack, haven't short-circuited early due to mismatch
            return parens == 0;

            // could also possibly check to make sure no brackets, or other unexpected characters, etc came after the last close paren
        }
    }
}