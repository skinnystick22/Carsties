export type PaginatedResult<T> = {
  data: T;
  pageNumber: number;
  pageSize: number;
  totalCount: number;
  totalPages: number;
};
