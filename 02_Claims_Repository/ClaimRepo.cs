using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Challenge
{
    public class ClaimRepo
    {
        private List<Claims> _claimRepo = new List<Claims>();
        private int _claimId = 1;

        //To Add, Read, and Delete

        //Add

        public bool AddClaim(Claims claimID)
        {
            int startingCount = _claimRepo.Count;
            claimID.ClaimID = _claimId;
            _claimRepo.Add(claimID);
            _claimId++;

            bool isAdded = (_claimRepo.Count > startingCount) ? true : false;
            return isAdded;

        }

        //Read

        //GetAllClaims
        public List<Claims> GetAllClaims()
        {
            return _claimRepo;
        }

        //GetAllClaimsById
        public Claims GetClaimByID(int claimsID)
        {
            foreach(Claims claims in _claimRepo)
            {
                if(claims.ClaimID == claimsID)
                {
                    return claims;
                }
            }

            return null;
        }

        //Delete

        public bool RemoveClaim(Claims existingClaim)
        {
            bool removedClaim = _claimRepo.Remove(existingClaim);
            return removedClaim;
        }

    }
}
