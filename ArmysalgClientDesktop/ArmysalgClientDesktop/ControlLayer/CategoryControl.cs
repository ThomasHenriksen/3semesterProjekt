using ArmysalgClientDesktop.ModelLayer;
using ArmysalgClientDesktop.Security;
using ArmysalgClientDesktop.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ArmysalgClientDesktop.ControlLayer
{
     class CategoryControl
    {
        CategoryServiceAccess _cAccess;


        public CategoryControl()
        {
            _cAccess = new CategoryServiceAccess();
        }

        public async Task<List<Category>> GetAllCategories()
        {
            List<Category> foundCategories = null; //await _cAccess.GetAllCategories(tokenVaule);

            TokenState currentState = TokenState.Valid;
            string tokenValue = await GetToken(currentState);
            if (tokenValue != null)
            {
                foundCategories = await _cAccess.GetAllCategories(tokenValue);
                if (_cAccess.CurrentHttpStatusCode == HttpStatusCode.Unauthorized)
                {
                    currentState = TokenState.Invalid;
                }
            }
            if (currentState == TokenState.Invalid)
            {
                tokenValue = await GetToken(currentState);
                if (tokenValue != null)
                {
                    foundCategories = await _cAccess.GetAllCategories(tokenValue);
                }
            }
            return foundCategories;
        }

        private async Task<string> GetToken(TokenState useState)
        {
            //string foundToken = null;
            TokenManager tokenHelp = new TokenManager();
            string foundToken = await tokenHelp.GetToken(useState);
            return foundToken;

        }

    }
}
