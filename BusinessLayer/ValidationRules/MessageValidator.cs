using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {

        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adresini boş geçemezsiniz");

            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu boş geçemezsiniz");
            RuleFor(x => x.Subject).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriş yapın");
            RuleFor(x => x.Subject).MaximumLength(1000).WithMessage("Lütfen 1000 karakterden fazla giriş yapmayın");
            
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Boş mesaj gönderemezsiniz");
        }
    }
}