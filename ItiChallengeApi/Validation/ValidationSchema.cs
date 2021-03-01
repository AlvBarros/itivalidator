namespace ItiChallengeApi.Validation
{
    public class ValidatePasswordRequest {
        public string Password { get; set; }
    }
    
    public class ValidatePasswordResponse {
        public bool Valid { get; set; }
        public ValidatePasswordResponse(bool valid) {
            this.Valid = valid;
        }
    }
}