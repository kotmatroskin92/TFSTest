using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TestFramework.Objects;

namespace ToyotaSpec.Pages
{
    public class VINWalkPage: BaseForm
    {

        public VINWalkPage(): base(By.Id("facet-checkboxGroup-IsSold"), "VIN Walk page")
        {
        }

        public void Click()
        {

        }
    }
}
