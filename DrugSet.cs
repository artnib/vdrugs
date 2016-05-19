using System.Collections.Generic;

namespace vdrugs
{
  /// <summary>
  /// Набор лекарств
  /// </summary>
  class DrugSet
  {
    /// <summary>
    /// Адрес аптеки
    /// </summary>
    public string Address;

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