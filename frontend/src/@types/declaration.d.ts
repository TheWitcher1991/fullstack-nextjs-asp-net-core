import React, { JSXElementConstructor } from 'react'

declare module '*.css'
declare module '*.scss'
declare module '*.sass'

declare global {
	type EmptyObject = Record<string, never>

	export type OnUploadProgress = (
		progress: number,
		uploaded: number,
		total: number,
	) => void

	type Nullable<T> = T | null

	type Size = 'sm' | 'md' | 'lg'

	type ImageData =
		| import('next/dist/shared/lib/get-img-props').StaticImport
		| string

	interface ReactElement<
		P = any,
		T extends string | JSXElementConstructor<any> =
			| string
			| JSXElementConstructor<any>,
	> {
		type: T
		props: P
		key: string | null
	}

	namespace JSX {
		interface Element extends React.ReactElement<any, any> {}
	}

	type ButtonVariant =
		| 'default'
		| 'primary'
		| 'secondary'
		| 'black'
		| 'danger'
		| 'overlay'

	type MenuItem = {
		name: string
		ico: ImageData
		href: string
		variant?: 'active' | 'disabled' | 'default'
		actions?: Partial<MenuItem>[]
		disabled?: boolean
	}

	type ChipVariant = 'default' | 'primary' | 'success' | 'warning' | 'danger'

	enum ErrorType {
		None,
		Validation,
		NotFound,
		Failure,
		Null,
		Conflict,
	}

	interface ResultError {
		code: string
		message: string
		type: ErrorType
	}

	interface ResultResponse<T> {
		result: T
		errors: Nullable<ResultError[]>
		isError: boolean
		timeGenerated: string
	}

	interface ValidationErrorResponse<
		T extends Record<string, any> = Record<string, any>,
	> {
		detail:
			| Array<{
					type: string
					loc: keyof T[] | string[]
					msg: string
					input: string
					ctx: Record<string, string | number>
			  }>
			| string
	}

	interface PagesListResponse<T> {
		pages: ResultResponse<T>[]
		pageParams: number[]
	}

	interface SocketIOMessage<IOM = string, IOA = string> {
		message: IOM
		action: IOA
	}

	interface ModalComponentProps {
		isOpen: boolean
		onClose: () => void
		minimal?: boolean
	}

	type SelectOption = {
		label: string
		value?: string
		disabled?: boolean
		selected?: boolean
		hr?: boolean
	}

	type OmitClassName<T> = Omit<T, 'className'>

	type DetailedDivProps = React.DetailedHTMLProps<
		React.ButtonHTMLAttributes<HTMLDivElement>,
		HTMLDivElement
	>

	type DetailedButtonProps = React.DetailedHTMLProps<
		React.ButtonHTMLAttributes<HTMLButtonElement>,
		HTMLButtonElement
	>

	type DetailedInputProps = React.InputHTMLAttributes<HTMLInputElement>

	type DetailedSelectProps = React.DetailedHTMLProps<
		React.SelectHTMLAttributes<HTMLSelectElement>,
		HTMLSelectElement
	>

	type DetailedLabelProps = React.DetailedHTMLProps<
		React.LabelHTMLAttributes<HTMLLabelElement>,
		HTMLLabelElement
	>

	type DetailedTextareaProps = React.DetailedHTMLProps<
		React.TextareaHTMLAttributes<HTMLTextAreaElement>,
		HTMLTextAreaElement
	>

	type Mapping = {
		[key: string | number | symbol]: any
	}

	interface PaginationPageSize {
		page: number
		pageSize: number
	}

	interface UseModelOptions<ORDERING = string> extends PaginationPageSize {
		search: string
		ordering: ORDERING
	}

	interface Collection {
		id: number
		title: string
	}

	type ModelListField<
		T,
		U extends Record<string, any>,
		M extends Record<string, any> = Record<string, any>,
	> = {
		count: number
		loading: boolean
		fetching?: boolean
		list: T[]
		filter: U
		meta: M
		checked?: Collection[]
	}

	type ModelListState<
		T,
		U extends Record<string, any>,
		M extends Record<string, any> = Record<string, any>,
	> = {
		setCount: (count: number) => void
		setLoading: (loading: boolean) => void
		setFetching: (fetching: boolean) => void
		setChecked: (checked: Collection[]) => void
		setList: (list: T[]) => void
		setMeta: (meta: M) => void
		setFilter: (filter: U) => void
		reset: () => void
	} & ModelListField<T, U, M>
}

export {}
