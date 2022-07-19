interface Wrapper<T> {
    result: T,
    isSuccessful: boolean;
    errors: string[];
    message: string;
}