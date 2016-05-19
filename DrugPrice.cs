using System;

namespace vdrugs
{
  /// <summary>
  /// Цена лекарства
  /// </summary>
  class DrugPrice
  {
    /// <summary>
    /// Лекарство
    /// </summary>
    public DrugInfo Drug;

    /// <summary>
    /// Цена
    /// </summary>
    public Decimal Price;

    /// <summary>
    /// Аптека
    /// </summary>
    public string Pharmacy;
  }
}