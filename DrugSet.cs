using System;
using System.Collections.Generic;

namespace vdrugs
{
  /// <summary>
  /// Набор лекарств
  /// </summary>
  public class DrugSet
  {
    /// <summary>
    /// Возвращает адрес аптеки
    /// </summary>
    public string Address
    {
      get
      {
        if (Drugs.Count > 0)
          return Drugs[0].Address;
        else
          return String.Empty;
      }
    }

    /// <summary>
    /// Возвращает название аптеки
    /// </summary>
    public string Pharmacy
    {
      get
      {
        if (Drugs.Count > 0)
          return Drugs[0].Pharmacy;
        else
          return String.Empty;
      }
    }

    /// <summary>
    /// Лекарства
    /// </summary>
    public List<DrugPrice> Drugs;

    /// <summary>
    /// Возвращает стоимость всех лекарств
    /// </summary>
    public decimal Total
    {
      get
      {
        decimal total = 0;
        foreach (DrugPrice dp in Drugs)
          total += dp.Price;
        return total;
      }
    }
  }
}