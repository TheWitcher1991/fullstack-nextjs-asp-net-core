import { z } from 'zod'

import {
	BookSchema,
	CreateBookFormSchema,
	CreateBookSchema,
	UpdateBookSchema,
} from '~models/book/book.schema'

export type IBook = z.infer<typeof BookSchema>

export type ICreateBook = z.infer<typeof CreateBookSchema>

export type IUpdateBook = z.infer<typeof UpdateBookSchema>

export type ICreateBookForm = z.infer<typeof CreateBookFormSchema>

export type UseBooks = UseModelOptions
