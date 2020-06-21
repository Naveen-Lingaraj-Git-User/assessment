using System;

namespace Assessment.Core.ViewModels
{
    public class AssessmentViewModel<T>
    {
        public T Result { get; set; }
        public bool HasError { get; set; }
        public string Error { get; set; }
    }
}
