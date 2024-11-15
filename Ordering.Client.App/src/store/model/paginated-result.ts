/* eslint-disable no-unused-vars */

/**
  * This is a TypeGen auto-generated file.
  * Any changes made to this file can be lost when this file is regenerated.
  * */

interface PaginatedResult<TEntity> {
  pageIndex: number;
  pageSize: number;
  count: number;
  data: TEntity[];
}
export default PaginatedResult;
