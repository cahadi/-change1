using System;
using System.Windows.Controls;

namespace ООО__Товары_для_животных_.Tools;

internal static class Capcha
{
    internal static string GenerateOnCanvas(Canvas canvas)
    {
        canvas.Children.Clear();

        string value = "";
        string temp;

        for (int i = 0; i < 5; i++)
        {
            if (Random.Shared.Next(0, 101) > 45)
            {
                temp = ((char)Random.Shared.Next(65, 91)).ToString();

                if (Random.Shared.Next(0, 101) > 50)
                    temp = temp.ToLower();
            }
            else
            {
                temp = Random.Shared.Next(0, 10).ToString();
            }

            TextBlock text = new ()
            {
                Text = temp,
                FontSize = Random.Shared.Next(33, 36)
            };

            canvas.Children.Add(text);

            Canvas.SetLeft(text, i * 10 + 5);
            Canvas.SetTop(text, 5 + Random.Shared.Next(-5, 5));

            value += temp;
        }

        return value;
    }
}