namespace Library.Common.Validations;
public static class BookValidations
{
    public const int TITLE_MIN_LENGTH = 10;
    public const int TITLE_MAX_LENGTH = 50;

    public const int AUTHOR_MIN_LENGTH = 5;
    public const int AUTHOR_MAX_LENGTH = 50;

    public const int DESCRIPTION_MIN_LENGTH = 5;
    public const int DESCRIPTION_MAX_LENGTH = 5000;

    public const decimal RATING_MIN_VALUE = 0;
    public const decimal RATING_MAX_VALUE = 10;

}