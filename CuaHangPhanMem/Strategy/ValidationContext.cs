using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangPhanMem.Strategy
{
    public enum ValidatorType{
        String,
        PositiveNumber,
        ID,
        Phone,
        Email
    }
    public class ValidatorContext
    {
        private string text;
        private IValidation validator;
        public ValidatorType _validatorType = ValidatorType.String;

        public ValidatorType validatorType
        {
            get => _validatorType;
            set
            {
                _validatorType = value;
                validator = SetAlgorithm();
            }
        }
        public ValidatorContext(string text)
        {
            this.text = text;
        }

        public ValidatorContext(string text, ValidatorType type)
        {
            this.text = text;
            this._validatorType = type;
            validator = SetAlgorithm();
        }

        public IValidation SetAlgorithm()
        {
            switch (validatorType)
            {
                case ValidatorType.ID:
                    return new IDValidation();
                case ValidatorType.Phone:
                    return new PhoneValidation();
                case ValidatorType.PositiveNumber:
                    return new PositiveNumberValidation();
                case ValidatorType.String:
                    return new StringValidation();
                case ValidatorType.Email:
                    return new EmailValidation();
                default:
                    return new StringValidation();
            }
        }

        public bool runValidation()
        {
            return validator.validation(text);
        }
    }
}
