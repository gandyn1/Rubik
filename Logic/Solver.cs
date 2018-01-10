using System;
using System.Collections.Generic;
using System.Linq;
using Rubik.BO;

namespace Rubik.Logic
{
    public partial class Solver
    {
        public Cube Cube { get; set; }
        private List<Action> Actions { get; set; }
        public Solver(Cube cube){
            this.Cube = cube;
            Actions = new List<Action>();
            Actions.Add(new ActionFront(cube.FaceFront));
            Actions.Add(new ActionFrontInverse(cube.FaceFront));

            Actions.Add(new ActionBack(cube.FaceBack));
            Actions.Add(new ActionBackInverse(cube.FaceBack));

            Actions.Add(new ActionRight(cube.FaceRight));
            Actions.Add(new ActionRightInverse(cube.FaceRight));

            Actions.Add(new ActionLeft(cube.FaceLeft));
            Actions.Add(new ActionLeftInverse(cube.FaceLeft));

            Actions.Add(new ActionTop(cube.FaceTop));
            Actions.Add(new ActionTopInverse(cube.FaceTop));

            Actions.Add(new ActionBottom(cube.FaceBottom));
            Actions.Add(new ActionBottomInverse(cube.FaceBottom));
        }

        public List<Action> Solve(){

            var a = Solve(() => Cube.FaceBottom.SolvedCount, 9);

            return null;
        }

        public List<Action> Solve(Func<int> countSolved, int maxToSolve)
        {
            var depth = 7;
            List<Action> ActionsTaken = new List<Action>();

            SolveRecursive(countSolved, new Stack<Action>(), 1, depth);

            return ActionsTaken;
        }

        public long ActionsTried { get; set; }

        private void SolveRecursive(Func<int> countSolved, Stack<Action> Taken, int level, int max){

            if (level > max)
            {
                return;
            }

            foreach(var action in Actions){

                //Taken.Push(action);
                action.Invoke();
                SolveRecursive(countSolved, Taken, level + 1, max);
                //Taken.Pop();
                action.Undo();

                ActionsTried++;
            }

        }
    }
}
