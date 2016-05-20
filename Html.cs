using System;
using System.Collections.Generic;

namespace vdrugs
{
  /// <summary>
  /// Средства работы с HTML
  /// </summary>
  static class Html
  {
    public static string[] GetRows(string table)
    {
      return table.Split(new string[] { "</tr>" }, StringSplitOptions.None);
    }

    public static List<string> GetCells(string row)
    {
      var cells = row.Split(new string[] { "</td>" }, StringSplitOptions.None);
      var clearCells = new List<string>(cells.Length);
      for (int i = 0; i < cells.Length; i++)
        clearCells.Add(ClearCell(cells[i]));
      return clearCells;
    }

    /// <summary>
    /// Возвращает значение элемента
    /// </summary>
    /// <param name="element">Элемент, обрамлённый тегами</param>
    /// <returns>Значение элемента</returns>
    public static string RemoveTags(string element)
    {
      var text = String.Empty;
      var closePos = element.LastIndexOf("</");
      if (closePos != -1)
      {
        var openPos = element.LastIndexOf(">", closePos);
        if (openPos != -1)
        {
          var valueStart = openPos + 1;
          text = element.Substring(valueStart, closePos - valueStart);
        }
      }
      return text;
    }

    /// <summary>
    /// Возвращает содержимое ячейки таблицы
    /// </summary>
    /// <param name="cell">Код ячейки</param>
    /// <returns>Содержимое ячейки</returns>
    static string ClearCell(string cell)
    {
      return cell.Replace("<td>", String.Empty).Trim();
    }
  }
}