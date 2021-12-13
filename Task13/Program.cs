using System;
using System.Windows.Forms;
using Model;

namespace View
{
    class PassportForm : Form
    {
        private TextBox _passport;
        private TextBox _result;

        private void OnButtonClicked(object sender, EventArgs e)
        {
            string passport = _passport.Text;
            var config = new Configuration();

            var result = config.Execute(passport);

            if (result is ValidationResult validationResult)
                Show(validationResult);
            else if (result is SearchResult searchResult)
                Show(searchResult);
        }

        private void Show(ValidationResult result) => _result.Text = Descriptions.NotValid;

        private void Show(SearchResult result)
        {
            switch (result.State)
            {
                case SearchResult.SearchState.Success:
                    _result.Text = "По паспорту «" + _passport.Text + "» доступ к бюллетеню на дистанционном электронном голосовании ПРЕДОСТАВЛЕН";
                    break;
                case SearchResult.SearchState.Fail:
                    _result.Text = "По паспорту «" + _passport.Text + "» доступ к бюллетеню на дистанционном электронном голосовании НЕ ПРЕДОСТАВЛЯЛСЯ";
                    break;
                case SearchResult.SearchState.NotFound:
                    _result.Text = "Паспорт «" + _passport.Text + "» в списке участников дистанционного голосования НЕ НАЙДЕН";
                    break;
                case SearchResult.SearchState.Error:
                    MessageBox.Show(Descriptions.SearchError);
                    break;
            }
        }
    }
}
