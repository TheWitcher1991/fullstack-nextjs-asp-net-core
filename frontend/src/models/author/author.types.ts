import { z } from 'zod'

import { AuthorSchema, BaseAuthorSchema } from '~models/author'

export type IAuthor = z.infer<typeof AuthorSchema>

export type ICreateAuthor = z.infer<typeof BaseAuthorSchema>

export type IUpdateAuthor = z.infer<typeof BaseAuthorSchema>

export type UseAuthors = UseModelOptions
