using System;

namespace vdrugs
{
  /// <summary>
  /// Сведения о лекарстве
  /// </summary>
  class DrugInfo
  {
    /// <summary>
    /// Название
    /// </summary>
    public string Name;

    /// <summary>
    /// Форма выпуска
    /// </summary>
    public string Option;

    public override string ToString()
    {
      return String.Format("{0} {1}", Name, Option);
    }

  }
}