using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCP.DAL.Queries
{
    public static class UserQueries
    {
        public static string INSERT = @"
INSERT INTO public.users
(id, email, first_name, last_name, password_salt, password_hash, created_date, stripe_customer_id)
VALUES(gen_random_uuid(), @email, @firstName, @lastName, @passwordSalt, @passwordHash, CURRENT_TIMESTAMP, null)
RETURNING id;
";

        public static string GET_BY_EMAIL = @"
SELECT 
    u.id
    , u.email
    , u.first_name
    , u.last_name
    , u.password_salt as passwordSalt
    , u.password_hash as passwordHash
    , u.created_date as createdDate
    , u.stripe_customer_id as stripeCustomerId
FROM users u
WHERE u.email = @email
";
    }
}
