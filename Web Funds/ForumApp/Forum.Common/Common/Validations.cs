namespace Forum.Common.Common;

public static class Validations
{
    public static class PostValidation
    {
        // Title
        public const int TITLE_MIN_LENGTH = 10;
        public const int TITLE_MAX_LENGTH = 50;

        // Content
        public const int CONTENT_MIN_LENGTH = 30;
        public const int CONTENT_MAX_LENGTH = 1500;
    }
}