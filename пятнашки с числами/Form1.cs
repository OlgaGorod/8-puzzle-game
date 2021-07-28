using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace пятнашки_с_числами
{
    public partial class FormMain : Form
        {
            Boolean ifStarted = new Boolean();
            int[] fArray = new int[9];
            Button[] myButtons; 
            MyRand rand = new MyRand();
            C_MovesOfButtons move = new C_MovesOfButtons();


        public FormMain()
        {
            InitializeComponent();
            CountOfSteps.Visible = false;
            labelSteps.Visible = false;
            ifStarted = false;
        }
        public void makeInviseble(Button[] myBut)//делает 0 кнопку невидимой
        {
            for (int i = 0; i < 9; i++)
                if (int.Parse(myBut[i].Text)==0)
                    myBut[i].Visible = false;
                else
                    myBut[i].Visible = true;
        }
            public void re()///обновление цифр на кнопках
          {
            for (int i = 0; i < 9; i++)
                myButtons[i].Text = fArray[i].ToString();
            labelSteps.Text= move.StepsCounter().ToString();//обновление счётчика ходов
            Win win = new Win();
            if (win.ifWin(fArray))//проверка на выигрышную кобинацию 
            {
                makeInviseble(myButtons);
                DialogResult dr = MessageBox.Show("Ещё разок?", "Победа!", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)//При желании игрока сыграть ещё раз
                    NewGame.PerformClick();//начинается новая игра
                else
                    this.Close();
            }
            makeInviseble(myButtons);
        }
        private void NewGame_Click(object sender, EventArgs e)//кнопка начала игры
        {
            ifStarted = true;
            labelSteps.Visible = true;
            CountOfSteps.Visible = true;
            move.restart();//метод, сбрасывающий счётчик ходов
            fArray = rand.toRand();//формирование массива случайных чисел

            //массив кнопок:
            myButtons = new Button[9] { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            for (int i = 0; i < 9; i++)
                myButtons[i].Text = fArray[i].ToString();//нанесение на кнопки случайного массива цифр
            makeInviseble(myButtons);//
            labelSteps.Text = "0";
        }
        private void GoOut_Click(object sender, EventArgs e)//кнопка выхода
        {
            DialogResult dialRes = MessageBox.Show("Вы уверены, что хотите выйти?", "Выйти?!", MessageBoxButtons.YesNo);
            if (dialRes == DialogResult.Yes)//проверка
                this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ifStarted)//если новая игра начата
            {
                fArray = move.MoveNumb(fArray, 0);//передвижение чисел в массиве
                this.re();//обновление цифр на кнопках
            }
        }
            private void button2_Click(object sender, EventArgs e)
        {
           
            if (ifStarted)
            {
                fArray = move.MoveNumb(fArray, 1);
                this.re();
            }
        }
            private void button3_Click(object sender, EventArgs e)
        {
            
            if (ifStarted)
            {
                fArray = move.MoveNumb(fArray, 2);
                this.re();
            }
        }
            private void button4_Click(object sender, EventArgs e)
        {
            
            if (ifStarted)
            {
                fArray = move.MoveNumb(fArray, 3);
                this.re();
            }
        }
            private void button5_Click(object sender, EventArgs e)
            {
            
            if (ifStarted)
                {
                    fArray = move.MoveNumb(fArray, 4);
                    this.re();
            }
            }
            private void button6_Click(object sender, EventArgs e)
        {
            
            if (ifStarted)
            {
                fArray = move.MoveNumb(fArray, 5);
                this.re();
            }
        }
            private void button7_Click(object sender, EventArgs e)
            {
            
            if (ifStarted)
            {
                fArray = move.MoveNumb(fArray, 6);
                this.re();
            }
            }
            private void button8_Click(object sender, EventArgs e)
            {
            
            if (ifStarted)
            {
                fArray = move.MoveNumb(fArray, 7);
                this.re();
            }
            }
            private void button9_Click(object sender, EventArgs e)
            {
            
            if (ifStarted)
                {
                    fArray = move.MoveNumb(fArray, 8);
                     this.re();
            }
            }

        private void labelSteps_Click(object sender, EventArgs e)//будем считать пасхалочкой
        {
            MessageBox.Show("Учитываются все передвижения цифр. Даже туда-обратно","Внимание!");
        }
    }

    public class C_MovesOfButtons
    {
        static int allSteps = 0;//счётчик ходов
        static int[] arrayOfNumbers = new int[9];
        static int k = 0;//переменная для запоминания, с цифрой какой кнопки нужно поменять цифру нажатой кнопки
        static Boolean isMoved;

        public int StepsCounter()//счётчик передвижений
        {
            if (isMoved == true)
                allSteps++;
            return allSteps;
        }
        public void restart()//сбрасывание счётчика
        {
            if (allSteps != 0)
                allSteps = 0;
        }
        public int[] MoveNumb(int[] arrayOfNumb, int butNumb)//перемещение
        {
            arrayOfNumbers = arrayOfNumb;
            isMoved = false;
            //проверка условия наличия нулевой клетки с одной из сторон (справа, слева, внизу или сверху) для перемещения
            //при выполнении условия цифры меняются местами в соответствующем массиве
            if (butNumb != 2 && butNumb != 5 && butNumb != 8)//для правой кнопки
                if (arrayOfNumbers[butNumb + 1] == 0)
                {
                    k = arrayOfNumbers[butNumb];
                    arrayOfNumbers[butNumb] = arrayOfNumbers[butNumb + 1];
                    arrayOfNumbers[butNumb + 1] = k;
                    isMoved = true;
                    k = 0;
                }
            if (butNumb < 6)//для нижней кнопки
                if (arrayOfNumbers[butNumb + 3] == 0)
                {
                    k = arrayOfNumbers[butNumb];
                    arrayOfNumbers[butNumb] = arrayOfNumbers[butNumb + 3];
                    arrayOfNumbers[butNumb + 3] = k;
                    isMoved = true;
                    k = 0;
                }
            if (butNumb != 0 && butNumb != 3 && butNumb != 6)//для левой кнопки
                if (arrayOfNumbers[butNumb - 1] == 0)
                {
                    k = arrayOfNumbers[butNumb];
                    arrayOfNumbers[butNumb] = arrayOfNumbers[butNumb - 1];
                    arrayOfNumbers[butNumb - 1] = k;
                    isMoved = true;
                    k = 0;
                }
            if (butNumb > 2)//для верхней кнопки
                if (arrayOfNumbers[butNumb - 3] == 0)
                {
                    k = arrayOfNumbers[butNumb];
                    arrayOfNumbers[butNumb] = arrayOfNumbers[butNumb - 3];
                    arrayOfNumbers[butNumb - 3] = k;
                    isMoved = true;
                    k = 0;
                }
            return arrayOfNumbers; //возвращение массива с обновленной расстановкой цифр
        }
    }

    public class MyRand
        {
            public int[] toRand()//рандомайзер
            {
                int[] fArray = new int[9]; 
                Random _random = new Random(); 
                int elementsofArray = 0; // переменная, считающая уже заданные элементы массива
                int rand = _random.Next(1, 10); // генерация числа с записью в переменную
                do
                {
                    int addElement = 0;
                    // проверка на совпадение вновь сгенерированного числа с любым из массива:
                    for (int i = 0; i < fArray.Length; i++)
                    {
                        if (fArray[i] != rand)
                            addElement++;
                        else
                            addElement--;
                    }
                    // если совпадений не найдено, то последнее сгенерированное число запсывается в следующую переменную
                    if (addElement == 9)
                    {
                        fArray[elementsofArray] = rand;
                        elementsofArray++;
                    }
                    // генерирование нового случайного числа, с которым потом будут сравниваться все уже существующие в массиве числа
                    rand = _random.Next(1, 10);
                }
                while (elementsofArray != 9); // генерация выполняется, пока в массиве не будет 8 уникальных чисел
                for (int i = 0; i < 9; i++)
                    if (fArray[i] == 9) fArray[i] = 0;//обозначение "пустой" клетки
                return fArray;
            }
        }

    public class Win
        {
            Boolean win = false;
            int k = 0;
            public Boolean ifWin(int[] arBut)
            {
                int[] arrayWin = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 0 };//выигрышная расстановка цифр в массиве
                for (int i = 0; i < 9; i++)
                    if (arBut[i] == arrayWin[i])
                        k++;
                if (k == 9) win = true;
                return win;
            }
        }
}