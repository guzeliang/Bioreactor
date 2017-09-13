﻿using System;

namespace Shunxi.Business.Protocols.SimDirectives
{
    public class LocationCompositeDirective:CompositeDirective
    {
        public override SimDirectiveType DirectiveType => SimDirectiveType.Location;

        public LocationCompositeDirective(Action<SimDirectiveResult> cb)
        {
            this.SuccessHandler = cb;
        }
    }
}
